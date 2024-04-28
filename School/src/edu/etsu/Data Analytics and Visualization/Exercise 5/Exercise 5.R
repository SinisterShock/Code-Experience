# data <- read.csv(choose.files())

# Visualization
plot(data[,c("totalsales", "AdvertBudget")])
plot(data[,c("totalsales", "AirplayTimes")])
plot(data[,c("totalsales", "AttractivenessScore")])

# Linear Regression
linearmodel <- lm(data$totalsales ~ data$AdvertBudget)
summary(linearmodel)

# Multiple Regression

model2 <- lm(data$totalsales ~ data$AdvertBudget + data$AirplayTimes + data$AttractivenessScore)
summary(model2)