import { createApp } from 'vue'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import App from './App.vue'
import router from './router/index'
import store from './store'
import axios from './http'

const app = createApp(App)
app.config.globalProperties.$axios=axios;
app.use(store)
app.use(ElementPlus)
app.use(router)
app.mount('#app')


