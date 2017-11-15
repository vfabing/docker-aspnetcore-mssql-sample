FROM node:6
ARG source
WORKDIR /app
EXPOSE 4200
COPY ${source:-.} .

RUN npm install

ENTRYPOINT ["npm", "start"]
