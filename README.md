# ContatoAPI
Este é um repositório para estudos...

Este projeto tem como objetivo, apresentar uma API simples, tendo como dominio
o "Contato" e foi desenvolvido em .net core. Trabalhará junto a uma base orientada
a arquivo, MongoDB. 

Esta base deverá ser criada antes da execução. Venho utilizando docker para me
auxiliar neste momentos, portanto inicio um container apontando para porta que 
desejo e pronto!

As informações para criar esta base deverão ser alteradas junto ao arquivo
./ContatoAPI.Service/appsetings.json, substituindo os valores dos atributos de "Settings":
    "ConnectionString": "mongodb://{ip}:{porta}" 
    "DataBase": "{databaseName}"  


Para utilizar este serviço, será necessário solicitar uma token,
chamando  localhost:porta/token passando no corpo da chamada o
"username": "teste" e "password": "teste".





