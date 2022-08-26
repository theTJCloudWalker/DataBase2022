<template>
  <div id="app">
    <!-- 其他页 -->
    <el-container v-if="$route.meta.keepAlive">
      <el-header>
        <!-- 导航栏 -->
          <myHeader></myHeader>
      </el-header>
    </el-container>
 
    <!-- 登录页 -->
    <router-view ></router-view>
   </div>
</template>

<script>
import  myHeader  from "@/components/Header.vue";
export default {
  name: 'App',
  components: 
  {
    myHeader
  }
}
</script>

<style>
</style>
