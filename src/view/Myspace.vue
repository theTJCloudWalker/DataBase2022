<template>
  <div>
    <el-container style="height: 650px; border: 1px solid #eee">
      <el-aside  
        width="200px"
        style="background-color: #545c64"  
      >
        <el-menu 
          :default-openeds="['1']"
          background-color="#545c64"
          text-color="#fff"
          active-text-color="#ffd04b"
        >
          <el-sub-menu index="1">
              <template #title>账号信息</template>
              <router-link class="alink" to="/myspace/showinfo">
                <el-menu-item index="1-1">
                  基本信息
                </el-menu-item>
              </router-link>
              <router-link class="alink" to="/myspace/infoeditor">
                <el-menu-item index="1-2">
                  信息修改
                </el-menu-item>
              </router-link>
              <router-link class="alink" to="/myspace/imageup">
                <el-menu-item index="1-3">
                  头像修改
                </el-menu-item>
              </router-link>
              <router-link class="alink" to="/myspace/countmanage">
                <el-menu-item index="1-4">
                  账号管理
                </el-menu-item>
              </router-link>
          </el-sub-menu>

          <router-link class="alink" to="/myspace/passenger">
            <el-menu-item index="2">
              乘坐人信息
            </el-menu-item>
          </router-link>

          <el-sub-menu index="3">
            <template #title>我的订单</template>
            <el-menu-item-group>
              <router-link class="alink" to="/myspace/">
                <el-menu-item index="3-1">
                  待支付订单
                </el-menu-item>
              </router-link>

              <router-link class="alink" to="/myspace/">
                <el-menu-item index="3-2">
                  待评价订单
                </el-menu-item>
              </router-link>
            </el-menu-item-group>
          </el-sub-menu>

          <router-link class="alink" to="/myspace/recharge">
                <el-menu-item index="4">
                  充值页面
                </el-menu-item>
          </router-link>
        </el-menu>
      </el-aside>


      <el-container
        style="background-image: url(/static/logo/noticesbg.jpg);
        background-repeat: no-repeat;
        background-size:100% 100%;
        "
      >
        <el-main>
          <div style="width: 80%;margin: 0 auto">
            <router-view></router-view>
          </div>
        </el-main>
      </el-container>

    </el-container>

  </div>

</template>

<script>
import { useStore } from "vuex"
export default {
  name: "myspace",
  setup(){

        const store=useStore();
        console.log(store.state.userId);
  
  },
  data() {

    return {

    }
  },
  
};

</script>

<style scoped>
.el-header {
  background-color: #fbfdfb;
  color: #333;
  line-height: 60px;
}

.el-aside {
  color: #333;
}
.router-link-active {
  text-decoration: none;
}

.alink{

  text-decoration: none;
}


</style>

