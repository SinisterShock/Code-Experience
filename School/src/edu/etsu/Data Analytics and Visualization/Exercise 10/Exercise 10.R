data <- read.csv(choose.files())
head(data)
plot(data)

# compute and plot WSS(weighted sum statistics) for k=2 to k=15
k.max <- 15
wss <- sapply(1:k.max, function(k) {kmeans(data, k, nstart=50,iter.max=15)$tot.withinss})
wss

# plotting the WSS
plot(1:k.max, wss, type="b", pch=19, frame=FALSE, xlab="Number of clusters K", ylab="Total within-clusters sum of square")

# lets say the best number of clusters = 6
clusters.km <- kmeans(data,6)

# plotting the color-coded clusters
plot(data, col=clusters.km$cluster)


