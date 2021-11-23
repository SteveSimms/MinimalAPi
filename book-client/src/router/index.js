import { createWebHistory, createRouter } from 'vue-router'


import Home from '../components/Home.vue'
import Book from '../components/Book.vue'
const routes = [

    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/Book',
        name: 'Book',
        component: Book
    },
]


const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router