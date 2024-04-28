# data <- read.csv(choose.files())
head(data)

# removing yes, no columns
data <- data[,2:9]
head(data)
# Convert data to a matrix
datainMatrix <- data.matrix(data)
# chi square
install.packages("gmodels")
library(gmodels)
CrossTable(datainMatrix, chisq=TRUE,expected=TRUE,sresid=TRUE,format="SPSS")
