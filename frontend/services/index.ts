import axios from 'axios';

export const api = axios.create({
    baseURL: 'https://unisantos-interdisciplinar-server.azurewebsites.net'
});