# Stage 1: Build the React application
FROM node:22-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Stage 2: Serve the app with NGINX
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
# If using Create React App (CRA), replace 'dist' with 'build' above
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
