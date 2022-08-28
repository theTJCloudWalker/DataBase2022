const routes = [
    {
        name: 'Login',
        path: '/login',
        component: () => import('@/view/LoginRegister.vue')
    },

    {
        name: 'TicketInquiry',
        path: '/TicketInquiry',
        component: () => import('@/view/TicketInquiry.vue')
    },
    {
        name: 'FrontPage',
        path: '/',
        component: () => import('@/view/FrontPage.vue')
    },
    {
        name: 'OrderPage',
        path: '/order',
        component: () => import('@/view/OrderPage.vue')
    },
    {
        name: 'Myspace',
        path: '/myspace',
        component: () => import('@/view/Myspace.vue'),
        children:[
        {
          path: '/myspace/showinfo',
          name: 'showinfo',
          component: () => import('@/view/myspace/showinfo.vue')
        },
        {
            path: '/myspace/infoeditor',
            name: 'infoeditor',
            component: () => import('@/view/myspace/infoeditor.vue')
        },
        {
            path: '/myspace/imageup',
            name: 'imageup',
            component: () => import('@/view/myspace/imageup.vue')
        },
        {
            path: '/myspace/countmanage',
            name: 'countmanage',
            component: () => import('@/view/myspace/countmanage.vue')
        },
        {
            path: '/myspace/message',
            name: 'message',
            component: () => import('@/view/myspace/message.vue')
        },
        {   path: '/myspace/recharge',
            name: 'recharge',
            component: () => import('@/view/myspace/recharge.vue')
         },
        {
        path: '/myspace/passenger',
        name: 'passenger',
        component: () => import('@/view/myspace/passenger.vue')
        },
        {
            path: '/myspace/myorder',
            name: 'myorder',
            component: () => import('@/view/myspace/myorder.vue')
        },
        ]
        
    },
    {
        name: 'FaultPage',
        path: '/:catchAll(.*)',
        component: () => import('@/view/404.vue')
    },
    
];

export default routes