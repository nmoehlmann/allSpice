FROM node:18

WORKDIR /app

COPY ./allSpice.client /app/allSpice.client

RUN npm install allSpice.client
RUN npm run build allSpice.client

EXPOSE 7045

CMD ["npm", "start"]

