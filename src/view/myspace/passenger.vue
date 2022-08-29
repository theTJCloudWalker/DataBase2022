<template>
  <div>
    <el-button class="button" type="primary" @click="add">添加乘坐人</el-button>
    <PassengerCard 
        v-for="(item,index) in arr" 
        :key="index"
        :index="index"
        @remove="remove">
    </PassengerCard>
 </div>
</template>
<script>
import PassengerCard from '@/components/PassengerCard'
 
export default {
 
data() {
    return {
        arr:[0]
    };
},
components: {
    PassengerCard
},
methods: {
    //点击新增子组件 
    add(){
        this.arr.push({})
    },
 
    //删除子组件
    remove(n){
        this.arr.splice(n,1); 
    },
}
};
</script>