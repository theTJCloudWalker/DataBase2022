const routes = [
    {
        name: 'Login',
        path: '/login',
        meta: {keepAlive: false},
        component: () => import('@/view/LoginRegister.vue')
    },

    {
        name: 'TicketInquiry',
        path: '/TicketInquiry',
        meta: {keepAlive: true},
        component: () => import('@/view/TicketInquiry.vue')
    },
    {
        name: 'FrontPage',
        path: '/',
        meta: {keepAlive: true},
        component: () => import('@/view/FrontPage.vue')
    },

    {
        name: 'Myspace',
        path: '/myspace',
        meta: {keepAlive: true},
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
        {
            path: '/myspace/recharge',
            name: 'recharge',
            component: () => import('@/view/myspace/recharge.vue')
          },
          {
            path: '/myspace/passenger',
            name: 'passenger',
            component: () => import('@/view/myspace/passenger.vue')
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