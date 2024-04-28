# data <- read.csv(choose.files())
head(data)

install.packages("arules")
library(arules)

rules <- apriori(data)
inspect(rules)

rules2 <- apriori(data, parameter = list(minlen=2, supp=0.005, conf=0.8), appearance = list(rhs=c("Survived=No", "Survived=Yes"), default="lhs"))
rules2=sort(rules2,by="lift")
inspect(rules2)
