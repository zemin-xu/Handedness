import pandas as pd
import numpy as np
from sklearn import preprocessing
from sklearn.model_selection import train_test_split
from sklearn import svm

def np_load_data():
    filename = 'UserData.csv'
    raw_data = open(filename, 'rt')
    data = np.loadtxt(raw_data, delimiter=",", skiprows=1)

    label = data[:, -1] # for last column
    features = data[:, :-1] # for all but last column
    print(features)

    features_normalized = preprocessing.normalize(
        features, norm='l2', axis=1, copy=True, return_norm=False)

    x_train, x_test, y_train, y_test = train_test_split(
        features_normalized, label, test_size=0.50)

    return x_train,  x_test, y_train, y_test

def load_data():
    dataset = pd.read_csv('UserData.csv', delimiter=',')
    #print("len of data:", len(dataset))
    # check the number of features in the dataset
    #print("features in dataset: ",len(dataset.columns))
    # check data type
    #print("data type: ", dataset.dtypes.unique())
    return dataset

def parse_data(dataset):
    # get the last column as label
    df = pd.DataFrame(dataset)

    label = df.iloc[:,-1]
    features = df.drop(['is_right_handedness'], axis=1)



    features_normalized = preprocessing.normalize(
        features, norm='l2', axis=1, copy=True, return_norm=False)

    x_train, x_test, y_train, y_test = train_test_split(
        features_normalized, label, test_size=0.50)

    return x_train,  x_test, y_train, y_test

def SVM(x_train, x_test, y_train, y_test):
    estimator = svm.SVC()
    estimator.fit(x_train, y_train)
    y_predict = estimator.predict(x_test)

    return y_test, y_predict

def main():
    #dataset = load_data()
    x_train, x_test, y_train, y_test = np_load_data()
    y_test, y_predict = SVM(x_train, x_test, y_train, y_test)

    print("predict: ")
    print(y_predict)
    print("real: ")
    print(y_test)



if __name__ == '__main__':
    main()