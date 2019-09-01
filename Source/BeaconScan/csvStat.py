import csv
from os import path, listdir

from numpy import mean, std, sqrt
from scipy.stats import norm

DATA_PATH = "C:\\Users\\maxsw\\OneDrive\\바탕 화면\\data"
RESULT_PATH = "C:\\Users\\maxsw\\OneDrive\\바탕 화면"
RESULT_FILE_NAME = "result.csv"
STAT_FILE_NAME = "stat.csv"


def conf_int(data, conf=0.95):
    m = mean(data)
    n = len(data)
    k = norm.ppf((1 + conf) / 2., n - 1)
    h = k * std(data) / sqrt(n)
    return m - h, m + h


def in_conf(target, data, conf=0.95):
    l, h = conf_int(data, conf)
    return l < target < h


def main():
    result_data = []
    stat_data = []

    for f in listdir(DATA_PATH):
        with open(path.join(DATA_PATH, f), newline='') as csvFile:
            reader = csv.reader(csvFile)

            raw_data = []
            filt_data = []
            for row in reader:
                raw_data.append(int(row[1]))
                filt_data.append(float(row[2]))

            result_data.append([f.split('cm')[0], mean(raw_data), mean(filt_data), filt_data[-1]])
            stat_data.append([f.split('cm')[0], len(raw_data), std(raw_data), std(filt_data),
                              in_conf(mean(raw_data), raw_data), in_conf(mean(filt_data), filt_data), in_conf(filt_data[-1], filt_data),
                              in_conf(mean(raw_data), raw_data, 0.99), in_conf(mean(filt_data), filt_data, 0.99), in_conf(filt_data[-1], filt_data, 0.99)])

    with open(path.join(RESULT_PATH, RESULT_FILE_NAME), 'w', newline='') as resultFile:
        writer = csv.writer(resultFile)
        for data in result_data:
            writer.writerow(data)

    with open(path.join(RESULT_PATH, STAT_FILE_NAME), 'w', newline='') as resultFile:
        writer = csv.writer(resultFile)
        for data in stat_data:
            writer.writerow(data)


if __name__ == "__main__":
    main()
