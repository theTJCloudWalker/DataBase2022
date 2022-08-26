<template>
<div>
    <el-card class="box-card" :data="user">
    <template #header>
        <div class="card-header">
        <el-container>
        <span>乘坐人{{index}}</span>
        </el-container >
        <el-container>
            <el-button class="button"  @click="edit(index)">{{user.compile}}</el-button>
            <el-button class="button"  @click="del(index)">删除</el-button>
        </el-container>
        
        </div>
    </template>
    <ul>
        <li>
            <el-input v-model="user.name" v-if="user.seen"> </el-input>
            <span style="margin-left: 10px" v-else>{{user.name}}</span>
        </li>
        <li>
            <el-input v-model="user.id" v-if="user.seen"> </el-input>
            <span style="margin-left: 10px" v-else>{{user.id}}</span>
        </li>
        <li>
            <el-input v-model="user.sex" v-if="user.seen"></el-input>
            <span style="margin-left: 10px" v-else>{{user.sex}}</span>
        </li>     
        <li>
            <el-input v-model="user.email" v-if="user.seen"> </el-input>
            <span style="margin-left: 10px" v-else>{{user.email}}</span>
        </li>
        <li>
            <el-input v-model="user.address" v-if="user.seen"> </el-input>
            <span style="margin-left: 10px" v-else>{{user.address}}</span>
        </li>
    </ul>
    </el-card>
       
</div>
</template>
<script>
export default {
 
data() {
    return {
        user:{
            seen: false,
            compile: '编辑',
            name: '里三',
            id: 4408,
            sex: '男',
            email: '114514@163.com',
            address: '河北省',
            VIP:'vip',
        }
    };
},
props: ['index'],
methods: {
    del(n){
        this.$emit('remove',n);
    },
    edit(n){
        this.user.seen=!this.user.seen;
        if(this.user.seen){
            this.user.compile='完成';
        }
        else{
            this.user.compile='编辑';
        }
    }
}
};
</script>

<style>
  .card-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  .text {
    font-size: 14px;
  }

  .item {
    margin-bottom: 18px;
  }

  .box-card {
    width: 480px;
  }
</style>