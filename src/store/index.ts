import { createStore } from 'vuex'

export default createStore({
  state: {
    userId:"111"
  },
  getters: {
  },
  mutations: {
    set(state,value){
      state.userId=value;
    }
  },
  actions: {
  },
  modules: {
  }
})
