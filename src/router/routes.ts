const routes = [
    {
        name: 'Login',
        path: '/login',
        component: () => import('@/view/LoginRegister.vue')
    },
    {
        name: 'HomePage',
        path: '/',
        component: () => import('@/view/Home.vue')
    },
    {
        name: 'FaultPage',
        path: '/:catchAll(.*)',
        component: () => import('@/view/404.vue')
    },
    
];

export default routes