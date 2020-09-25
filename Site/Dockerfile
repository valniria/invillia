FROM node:latest as angular
WORKDIR /app
COPY package.json /app
RUN npm install --silent
COPY . .
RUN npm run build


FROM nginx:alpine
VOLUME "/var/cache/nginx"
COPY --from=angular app/dist/Site /user/share/nginx/html
COPY nginx.conf /etc/ngix/conf.d/default.conf