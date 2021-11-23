<script setup>
    import { ref, computed } from 'vue'
  /*  import { useStore } from 'vuex'*/
    import axios from 'axios'

    let isExpanded = ref(false)

    const log = console.log()

    function collapse() {
        isExpanded.value = false
    }

    function toggle() {
        isExpanded.value = !isExpanded.value
    }

    //const store = useStore()

    //const auth = computed(() => store.state.authenticated)

    //async function logout() {
    //    await axios.post('http://localhost:50598/api/logout')
    //        .then((response) => {
    //            log(response)
    //        })
    //}
</script>




<template>
    <header class="fixed-top">
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container">
                <a class="navbar-brand">BookShlv</a>
                <button class="navbar-toggler"
                        type="button"
                        data-toggle="collapse"
                        data-target=".navbar-collapse"
                        aria-label="Toggle navigation"
                        @click="toggle">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"
                     v-bind:class="{show: isExpanded}">
                    <ul class="navbar-nav flex-grow">
                        <li class="nav-item">
                            <router-link :to="{ name: 'Home' }" class="nav-link text-dark">Home</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'AddBook' }" class="nav-link text-dark">Add Book</router-link>
                        </li>

                        <!--<li class="nav-item">
        <router-link :to="{ name: 'Login' }" class="nav-link text-dark">Login </router-link>
    </li>
    <li class="nav-item">
        <router-link :to="{ name: 'Register' }" class="nav-link text-dark">Register</router-link>
    </li>
    <li class="nav-item">
        <router-link :to="{ name: 'Login' }" class="nav-link text-dark" @click="logout">Logout </router-link>-->
                        <!--<a href="#" class="nav-link" @click="logout">Logout</a>-->
                        <!--</li>-->
                    </ul>





                </div>
            </div>
        </nav>
    </header>
</template>


<style>
    a.navbar-brand {
        white-space: normal;
        text-align: center;
        word-break: break-all;
    }

    html {
        font-size: 14px;
    }

    @media (min-width: 768px) {
        html {
            font-size: 16px;
        }
    }

    .box-shadow {
        box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
    }
</style>



