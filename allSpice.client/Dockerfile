FROM node:18

WORKDIR /app

COPY package*.son ./
RUN npm install

COPY . .

EXPOSE 7045

CMD ["npm", "start"]

