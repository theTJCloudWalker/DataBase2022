<template>
  <div>
    <router-link class="alink" to="../../">
    <el-page-header 
        content="个人中心" @back="goBack"
    />
    </router-link>
    <el-container style="height: 700px; border: 10px solid #eee">
      <el-aside  
        width="150px"
        style="background-color: #545c64"  
      >
        <el-menu 
          :default-openeds="['1']"
          background-color="#545c64"
          text-color="#fff"
          active-text-color="#ffd04b"
        >

          <el-submenu index="1">
            <template slot="title">
              <i class="el-icon-postcard"></i>信息</template>
            <el-menu-item-group>

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


            </el-menu-item-group>

          </el-submenu>

          <el-submenu index="2">
            <template slot="title">
              <i class="el-icon-star-on"></i>订单</template>

            <el-menu-item-group>

              <router-link class="alink" to="/myspace/">
                <el-menu-item index="5-1">
                  历史订单
                </el-menu-item>
              </router-link>

              <router-link class="alink" to="/myspace/">
                <el-menu-item index="5-2">
                  正在进行的订单
                </el-menu-item>
              </router-link>


            </el-menu-item-group>


          </el-submenu>

          <el-submenu index="3">
            <template slot="title">
              <i class="el-icon-star-on"></i>行李</template>

            <el-menu-item-group>

              <router-link class="alink" to="/myspace/">
                <el-menu-item index="5-1">
                  我的行李
                </el-menu-item>
              </router-link>

              <router-link class="alink" to="/myspace/">
                <el-menu-item index="5-2">
                  亲属行李
                </el-menu-item>
              </router-link>


            </el-menu-item-group>


          </el-submenu>

          <el-submenu index="4">
            <template slot="title">
              <i class="el-icon-star-on"></i>消息</template>

            <el-menu-item-group>

              <router-link class="alink" to="/myspace/message">
                <el-menu-item index="5-1">
                  系统通知
                </el-menu-item>
              </router-link>
              
            </el-menu-item-group>


          </el-submenu>
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
export default {
  name: "myspace",
  data() {

    return {

    }
  },
  
};
const goBack = () => {
  alert('go back')
}
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

