# data = read.csv('C:/Users/Tyler/Downloads/Income Dirty Data.csv', header=TRUE)

# Check what data is "complete" and remove NA records
data_complete <- na.omit(data)
# 733 records / 1000 records ~73%
data_complete

# create correction rules
cr <- correctionRules(expression(if(!is.na(age) & age <18) age <- NA,
                                 if(!is.na(income) & income <1) income <- NA,
                                 if(is.na(income) & !is.na(tax..15..)) income <- (tax..15.. / 0.15),
                                 if(!is.na(tax..15..) & (is.na(income) | tax..15.. != (income * 0.15))) tax..15.. <- NA,
                                 if(!is.na(gender) & gender =="Man") gender <- "Male",
                                 if(!is.na(gender) & gender =="Men") gender <- "Male",
                                 if(!is.na(gender) & gender =="Woman") gender <- "Female",
                                 if(!is.na(gender) & gender =="Women") gender <- "Female",
                                 if(is.na(tax..15..) & !is.na(income)) tax..15.. <- (income * 0.15)))

# apply rules
corule <- correctWithRules(cr,data)
newdata <- corule$corrected
newdata


# find what data had no errors
prune_data <- corule$corrected
prune_data <- na.omit(prune_data)

plot(as.factor(newdata$gender))

# If it's a factor, convert it to character to get counts
if (is.factor(newdata$gender)) {
  newdata$gender <- as.character(newdata$gender)
}

# Check the unique values and their counts
gender_counts <- table(addNA(newdata$gender))
print(gender_counts)
summary(newdata)

# KNN  
data_imputation <- kNN(newdata)
data_imputation

sum(is.na(data_imputation))

summary(data_imputation)
