<template>
    <el-menu
    ref="myHeader"
    :default-active="activeIndex"
    mode="horizontal"
    @select="handleSelect"
    >
    <router-link class="alink" to="../">
      <el-menu-item index="1">机票</el-menu-item>
    </router-link>
    
    <router-link class="alink" to="../myspace">
      <el-menu-item index="2">个人中心</el-menu-item>
    </router-link>

    <router-link class="alink" to="../login">
      <el-menu-item index="3">登录/注册</el-menu-item>
    </router-link>

    </el-menu>
</template>
<script>
export default {
    data() {
      return {
        activeIndex: '1',
        activeIndex2: '1',
      }
    },
    methods: {
      handleSelect(key, keyPath) {
        console.log(key, keyPath)
      },
    },
  }
</script>

<style>
.alink{

  text-decoration: none;
}
</style>