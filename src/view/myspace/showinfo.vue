<template>
<div>
  <el-card class="box-card" :data="user">
    <div  style="width:14%;height: 130px;border-radius: 100px;display:inline-block;">
      <img
        style="width:100%;height: 100%;border-radius: 100px"
        src=""
        class="image"
      >
    </div>

  <br>
  <br>
  <el-descriptions :column="1" border>

    <el-descriptions-item label="用户名" v-model="username" ><p class="message">{{username}}</p></el-descriptions-item>
    <el-descriptions-item label="身份证" v-model="id"><p class="message">{{id}}</p></el-descriptions-item>
    <el-descriptions-item label="住址" v-model="address"><p class="message">{{address}}</p></el-descriptions-item>
    <el-descriptions-item label="VIP" v-model="VIP"><p class="message">{{VIP}}</p></el-descriptions-item>

  </el-descriptions>
  </el-card>
</div>
</template>

<script>
export default {
  name: "showinfo",
  data(){
    return{
      username: "username",
      id: "4408xxxxxxxxx",
      address: "火星",
      VIP: true,

    }
  }
}
</script>

<style scoped>
.message{
  width: 20em;
  overflow: hidden;
  text-overflow:ellipsis;
  white-space: nowrap;
}

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
