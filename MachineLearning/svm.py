import pandas as pd
import numpy as np
from sklearn import preprocessing
from sklearn.model_selection import GridSearchCV
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
from sklearn import svm

def load_parse_data():
    filename = '../Assets/Data/UserData.csv'
    raw_data = open(filename, 'rt')
    data = np.loadtxt(raw_data, delimiter=",", skiprows=1)

    label = data[:, -1] # for last column
    features = data[:, :-1] # for all but last column

    label = label.astype('int')

    features_normalized = preprocessing.normalize(
        features, norm='l2', axis=1, copy=True, return_norm=False)

    x_train, x_test, y_train, y_test = train_test_split(
        features_normalized, label, test_size=0.50)

    return x_train,  x_test, y_train, y_test

def parse_data(dataset):
    # get the last column as label
    df = pd.DataFrame(dataset)

    label = df.iloc[:,-1]
    features = df.drop(['is_right_handedness'], axis=1)

    features_normalized = preprocessing.normalize(
        features, norm='l2', axis=1, copy=True, return_norm=False)

    x_train, x_test, y_train, y_test = train_test_split(
        features_normalized, label, test_size=0.33)

    return x_train,  x_test, y_train, y_test

def SVM(x_train, x_test, y_train, y_test, best_params):
    estimator = svm.SVC().set_params(**best_params)
    estimator.fit(x_train, y_train)
    y_predict = estimator.predict(x_test)

    return y_test, y_predict

def SVC_grid_search(x_train, y_train):
    parameters = {'kernel': ['linear', 'sigmoid', 'poly', 'rbf'],
                  'gamma': ['scale','auto'],
                  'degree': [1,2,3,4,5,6,7],
             }

    grid = GridSearchCV(estimator=svm.SVC(),param_grid=parameters,
                        n_jobs=-1, cv=10)
    grid.fit(x_train, y_train)
    return grid.best_score_, grid.best_params_

def main():
    x_train, x_test, y_train, y_test = load_parse_data()

    best_params = 0
    best_score = 0
    for i in range(5):
        score, params = SVC_grid_search(x_train, y_train)
        if (score > best_score):
            best_score = score
            best_params = params

    print("Best parameters: ", best_params)
    print("Theoretical score: ", best_score)

    accuracys = []
    for i in range(10):
        y_test, y_predict = SVM(x_train, x_test, y_train, y_test, best_params)
        accuracy = accuracy_score(y_test, y_predict)
        accuracys.append(accuracy)

    res = np.mean(accuracys)
    print("Actual score: ", res)

if __name__ == '__main__':
    main()