# data = read.csv(file.choose())



cova_SE = cov(data$salary, data$education)
print(cova_SE)

cova_SP = cov(data$salary, data$prestige)
print(cova_SP)

cova_EP = cov(data$education, data$prestige)
print(cova_EP)

corr_SE = cor.test(data$salary, data$education, method = "pearson")
corr_SE$estimate
corr_SE$p.value

corr_SP = cor.test(data$salary, data$prestige, method = "pearson")
corr_SP$estimate
corr_SP$p.value

corr_PE = cor.test(data$prestige, data$education, method = "pearson")
corr_PE$estimate
corr_PE$p.value