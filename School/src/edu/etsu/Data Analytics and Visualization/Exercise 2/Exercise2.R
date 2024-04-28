data = read.csv(file.choose())

summary(data)

hist(data[,c("prestige")])

hist(data[,c("education")])

plot(data[,c("salary", "education")])

plot(data[,c("education", "prestige")])

datavar = var(data[,c("salary")])
sqrt(datavar)
