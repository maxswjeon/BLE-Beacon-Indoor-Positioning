from threading import Thread
import bluetooth._bluetooth as bluez
import blescan
import json

from flask import Flask
from flask_restful import Resource, Api

BLUETOOTH_NONE = 0x00
BLUETOOTH_SCANNING = 0x01


class BluetoothManager:
    def __init__(self):
        self.sock = bluez.hci_open_dev(0)
        self.beacons = []
        self.scanThread = None
        self.__scan_stop = False
        self.status = BLUETOOTH_NONE
        self.info = {
            'uuid': '416d147a46374c4e83af715c1058c95a',
            'major': 0x1234,
            'minor': 0xabcd
        }

    def start_scan(self):
        if self.scanThread is None:
            self.__scan_stop = False
            self.scanThread = Thread(target=self._scan)
            self.scanThread.start()
            self.status = BLUETOOTH_SCANNING

    def stop_scan(self):
        self.__scan_stop = True
        self.scanThread = None
        self.status = BLUETOOTH_NONE

    def get_scan(self):
        beaconlist = self.beacons
        self.beacons = []
        return beaconlist

    def _scan(self):
        blescan.hci_le_set_scan_parameters(self.sock)
        blescan.hci_enable_le_scan(self.sock)
        while not self.__scan_stop:
            beaconlist = blescan.parse_events(self.sock, 10)
            for beacon in beaconlist:
                self.beacons.append(beacon)


app = Flask(__name__)
api = Api(app)
bleManager = BluetoothManager()


class StartScan(Resource):
    def get(self):
        bleManager.start_scan()
        return {'status': True}


class StopScan(Resource):
    def get(self):
        bleManager.stop_scan()
        return {'status': True}


class GetScan(Resource):
    def get(self):
        return bleManager.get_scan()


class GetStatus(Resource):
    def get(self):
        return {'status': bleManager.status}


class GetInfo(Resource):
    def get(self):
        f = open("/boot/info.txt")
        info = f.read()
        f.close()
        return json.loads(info)


api.add_resource(StartScan, '/start')
api.add_resource(StopScan, '/stop')
api.add_resource(GetStatus, '/status')
api.add_resource(GetScan, '/scan')
api.add_resource(GetInfo, '/info')
app.run(debug=True)
