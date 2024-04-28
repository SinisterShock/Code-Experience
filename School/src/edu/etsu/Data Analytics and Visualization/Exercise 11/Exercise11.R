# car data Problem 1 ==========================
# filtering out irrelevant columns from mtcars
cars = mtcars[, c("mpg", "qsec", "hp")]

# calculate outliers
install.packages("mvoutlier")
library(mvoutlier)
uni.plot(cars)
# Problem 1- End     ==========================

# Bank Data Problem 2 =========================
data <- read.csv(choose.files())
head(data)

# Collecting relevant column indexes
c <- c(1,5,6,7,11,13,14)

# Drawing the boxplot
boxplot(data[,c])
b1<- boxplot(data[,1])
b5<- boxplot(data[,5])
b6<- boxplot(data[,6])
b7<- boxplot(data[,7])
b11<- boxplot(data[,11])
b13<- boxplot(data[,13])
b14<- boxplot(data[,14])

# Viewing the values 
which(data[,1] %in% b1$out)

#calculating outliers on all attributes using a distance function
install.packages("cluster")
library(cluster)

dist=daisy(data[,-19],stand=TRUE, metric=c("gower"), type=list(nominal=c(2,4,12),symm=c(3),asymm=c(10,15,16)))

install.packages("DMwR2")
library(DMwR2)

out= outliers.ranking(dist, method = "sizeDiff", meth="ward.D")
# printing the top 10
print(out$rank.outliers, max = 10)

# Problem 2- End      =========================
