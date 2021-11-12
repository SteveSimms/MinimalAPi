<script setup>
    import { ref } from 'vue'
    import { reactive } from 'vue'
    import axios from 'axios'
    
    defineProps({
        msg: String
    })

    const count = ref(0)
    const state = reactive({
        message: 'empty'
    })

    axios.get('http://localhost:5106/test')
        .then(res => res.data)
            .then(t => state.message = t)
</script>

<template>
    <h1>{{ msg }}</h1> 
    <h1>{{ state.message }}</h1>
  

    <p>
        Recommended IDE setup:
        <a href="https://code.visualstudio.com/" target="_blank">VSCode</a>
        +
        <a href="https://github.com/johnsoncodehk/volar" target="_blank">Volar</a>
    </p>

    <p>
        <a href="https://vitejs.dev/guide/features.html" target="_blank">
            Vite Documentation
        </a>
        |
        <a href="https://v3.vuejs.org/" target="_blank">Vue 3 Documentation</a>
    </p>

    <button type="button" @click="count++">count is: {{ count }}</button>
    <p>
        Edit
        <code>components/HelloWorld.vue</code> to test hot module replacement.
    </p>
</template>

<style scoped>
    a {
        color: #42b983;
    }
</style>
