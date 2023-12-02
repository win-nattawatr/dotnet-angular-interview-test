FROM node:20.10-alpine3.17 as base
WORKDIR /app
COPY ./package*.json ./
RUN npm install
COPY . .

FROM base as development
CMD ["npm", "run", "start"]

FROM base as build
RUN npm run build

FROM node:20.10-alpine3.17 as production
WORKDIR /release
COPY --from=build /app/package.json /release
COPY --from=build /app/dist /release/dist

CMD ["npm", "run", "serve:ssr:Frontend"]