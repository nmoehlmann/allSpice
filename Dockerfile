FROM node:18

WORKDIR /app

COPY ./allSpice.client /app/allSpice.client

RUN npm install
RUN npm run build

EXPOSE 7045

CMD ["npm", "start"]

