#!/bin/sh

java -jar swagger-codegen-cli-3.0.24.jar generate \
    -l typescript-angular \
    -i http://localhost:5002/swagger/v1/swagger.json \
    -o ../services/swagger-generated






