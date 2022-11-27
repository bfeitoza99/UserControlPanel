FROM node:alpine AS builder

WORKDIR /ang

COPY . .

RUN npm i --force && npm run build

FROM nginx:alpine

WORKDIR /usr/share/nginx/html

RUN rm -rf ./*

COPY --from=builder /ang/dist/user-panel .

ENTRYPOINT [ "nginx","-g","daemon off;" ]
