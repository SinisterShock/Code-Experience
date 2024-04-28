#data = read.csv(file.choose())

data$salary
data$education

subset(data, salary>=127)

subset(data, salary > mean(data$salary))
