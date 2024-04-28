data <- read.csv(choose.files())
head(data)

# Impute the data with kNN 
install.packages("VIM")
library("VIM")
data_imputation <- kNN(data)


# Cleaning Outliers
# Q1 Q3 IQR if data appincome > = lower threshold <= upper threshold -> clean data

#cleaning Applicant
Q1A = quantile(data_imputation$ApplicantIncome, .25)
Q3A = quantile(data_imputation$ApplicantIncome, .75)

IQRA = IQR(data_imputation$ApplicantIncome)

cleaned_AppData = subset(data_imputation, data_imputation$ApplicantIncome >= (Q1A - 1.5*IQRA) & data_imputation$ApplicantIncome <= (Q3A+1.5*IQRA))


#cleaning Coapplicant
Q1C = quantile(data_imputation$CoapplicantIncome, .25)
Q3C = quantile(data_imputation$CoapplicantIncome, .75)

IQRC = IQR(data_imputation$CoapplicantIncome)

cleaned_CoData = subset(data_imputation, data_imputation$CoapplicantIncome >= (Q1C - 1.5*IQRC) & data_imputation$CoapplicantIncome <= (Q3C+1.5*IQRC))

# combined clean
cleaned_Data = subset(data_imputation, data_imputation$CoapplicantIncome >= (Q1C - 1.5*IQRC) & data_imputation$CoapplicantIncome <= (Q3C+1.5*IQRC) & data_imputation$ApplicantIncome >= (Q1A - 1.5*IQRA) & data_imputation$ApplicantIncome <= (Q3A+1.5*IQRA))
# writing clean data to a new csv
write.csv(cleaned_Data, "CleanedData_R.csv")

# 5 number summary requested in the report
summary(cleaned_Data$ApplicantIncome)
summary(cleaned_Data$CoapplicantIncome)
summary(cleaned_Data$LoanAmount)

# visualization
# Figure 1
accepted_loans <- subset(cleaned_Data, Loan_Status == "Y")
pie(table(accepted_loans$Married), main = "Married Status of Accepted Loans", col = c("lightblue", "lightgreen"))

# Figure 2
rejected_loans <- subset(cleaned_Data, Loan_Status == "N")
pie(table(rejected_loans$Married), main = "Married Status of Rejected Loans", col = c("lightblue", "lightgreen"))

# Figure 2
plot(cleaned_Data$ApplicantIncome, type = "l", col = "blue", xlab = "Index", ylab = "Income", main = "ApplicantIncome and CoapplicantIncome")
lines(cleaned_Data$CoapplicantIncome, col = "red")
legend("topright", legend = c("ApplicantIncome", "CoapplicantIncome"), col = c("blue", "red"), lty = 1)

plot(cleaned_Data$ApplicantIncome, cleaned_Data$CoapplicantIncome, col = "blue", xlab = "ApplicantIncome", ylab = "CoapplicantIncome", main = "ApplicantIncome vs CoapplicantIncome")

# Figure 4

boxplot(cleaned_Data$ApplicantIncome, main = "Boxplot of Applicant Income", ylab = "Income Amount")
boxplot(cleaned_Data$CoapplicantIncome, main = "Boxplot of Coapplicant Income", ylab = "Income Amount")
boxplot(cleaned_Data$LoanAmount, main = "Boxplot of Loan Amount", ylab = "Loan Amount")
