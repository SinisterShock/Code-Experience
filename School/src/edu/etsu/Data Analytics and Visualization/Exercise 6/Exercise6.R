data <- read.csv(choose.files())
install.packages("caret")
library(caret)
head(data)

# splitting the data into 20% testing, 80% training
TestingSample = floor(0.2*nrow(data))
TestingSample = sample(seq_len(nrow(data)),size=TestingSample)

testData <- data[TestingSample,]
trainData <- data[-TestingSample,]
dim(testData)

# Building the decision tree
install.packages("rpart", dependencies = TRUE)
library(rpart)
install.packages("rpart.plot")
library(rpart.plot)


tree <- rpart(Label ~ ., data = trainData)

rpart.plot(tree)

tree.predicted <- predict(tree, testData, type="class")
u<-union(tree.predicted, testData$Label)
t<-table(factor(tree.predicted, u), factor(testData$Label, u))

confusionMatrix(t)

install.packages("naivebayes")
library(naivebayes)

nmodel <- naive_bayes(Label ~ ., data = trainData)
prediction <- predict(nmodel, testData)

nU<-union(prediction, testData$Label)
nT<-table(factor(prediction, nU), factor(testData$Label, nU))

confusionMatrix(nT)
