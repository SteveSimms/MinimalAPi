import { createWebHistory, createRouter } from 'vue-router'


import Home from '../components/Home.vue'
import Book from '../components/Book.vue'
import AddBook from '../components/AddBook.vue'
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
    {
        path: '/AddBook',
        name: 'AddBook',
        component: AddBook
    },
]


const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router