<template>
  <div class="background">
    <div class="buttonrow">
      欢迎您，{{ Username }}! 这地方到时候是不是顶部栏
      <router-link to="/Myspace" class="toSpace">
        <el-button> 个人中心</el-button>
      </router-link>
    </div>
    <!--  -->
    <div class="search-form">
      <!-- 起始地选择 -->
      <div class="form-line">
        <div class="flt-box">
          <!-- 起点 -->
          <div class="flt-depart">
            <span>出发地</span>
            <div class="select-box">
              <el-select
                v-model="departure"
                placeholder="请选择出发地"
                filterable
                @click="setCacheDep"
              >
                <el-option
                  v-for="item in cities"
                  :key="item.value"
                  :label="item.label"
                  :value="item.value"
                />
              </el-select>
            </div>
          </div>
          <!-- 交换按钮 -->
          <div>
            <el-icon class="switch-button" size="large" @click="exchange">
              <Refresh
            /></el-icon>
          </div>
          <!-- 终点 -->
          <div class="flt-arrival">
            <span>目的地</span>
            <div class="select-box">
              <el-select
                v-model="destination"
                placeholder="请选择目的地"
                filterable
                @click="setCacheDes"
              >
                <el-option
                  v-for="item in cities"
                  :key="item.value"
                  :label="item.label"
                  :value="item.value"
                />
              </el-select>
            </div>
          </div>
        </div>
        <!-- 选择日期 -->
        <div class="date-box">
          <span>出发日期</span>
          <div class="date-picker">
            <el-date-picker
              v-model="depDate"
              type="date"
              placeholder="选择出发日期"
              :disabled-date="disabledDate"
            />
          </div>
        </div>
      </div>
    </div>
    <!--  -->
    <div>
      <!-- <router-link to="/TicketInquiry" class="search"> -->
      <div class="search">
        <el-button class="search-button" @click="search"> 搜索</el-button>
        <svg
          viewBox="0 0 1024 1024"
          xmlns="http://www.w3.org/2000/svg"
          data-v-ba633cb8=""
        >
          <path
            fill="currentColor"
            d="m795.904 750.72 124.992 124.928a32 32 0 0 1-45.248 45.248L750.656 795.904a416 416 0 1 1 45.248-45.248zM480 832a352 352 0 1 0 0-704 352 352 0 0 0 0 704z"
          ></path>
        </svg>
      </div>
      <!-- </router-link> -->
    </div>
    <!--  -->
  </div>
</template>

<script>
//import { defineComponent } from '@vue/composition-api'
import { ref } from "vue";
import TicketInquiry from "./TicketInquiry.vue";
import { useRouter } from "vue-router";

export default {
  name: "FrontPage",
  components: { TicketInquiry },
  data() {
    return {
      cacheDep: "", //缓存上一个填入的地点，用来处理同地点
      cacheDes: "",
      departure: "上海",
      destination: "哈尔滨",
      Username: "user",
      depDate: "",
      disabledDate: "",

      disabledDate(time) {
        //函数，禁用日期
        return time.getTime() < Date.now() - 8.64e7;
      },

      cities: [
        {
          value: "哈尔滨",
          label: "哈尔滨(HRB)",
        },
        {
          value: "上海",
          label: "上海(HRB)",
        },
      ],
    };
  },

  methods: {
    exchange() {
      //交换函数
      let temp = "";
      temp = this.departure;
      this.departure = this.destination;
      this.destination = temp;
      //console.log(this.departure,this.destination,this.cacheDep,this.cacheDes);
      //console.log(this.depDate);
    },
    setCacheDep() {
      //设置缓冲下同
      this.cacheDep = this.departure;
    },
    setCacheDes() {
      this.cacheDes = this.destination;
    },
    search() {
      console.log("带值跳转，不知道如何实现");
      this.$router.push({
        path: "/TicketInquiry",
        //这里传的是一个对象
        query: {
          name:'routeSearch',
          departure: this.departure,
          destination: this.destination,
          depDate: this.depDate,
        },
      });
    },
  },

  watch: {
    departure() {
      //监视器，监视相同时交换
      if (this.departure === this.destination) {
        this.departure = this.cacheDep;
        this.exchange();
      }
    },
    destination() {
      //监视器，监视相同时交换
      if (this.departure === this.destination) {
        this.destination = this.cacheDes;
        this.exchange();
      }
    },
  },

  mounted() {
    this.depDate = new Date();
    //console.log(this.depDate);
  },
};
</script>

<style scoped>
.background {
  /* background-color: aqua; */
  width: 1537px;
  height: 100%;
  background-size: cover;
  background: linear-gradient(to bottom, rgb(192, 255, 255), white);
  position: relative;
  display: flex;
  flex-direction: column;
  position: relative;
  align-items: center;
  left: -10px;
  top: -10px;
}

.buttonrow {
  margin-right: 50px;
  margin-top: 20px;
  text-align: right;
  font-size: 20px;
}

.title {
  margin-top: 100px;
  text-align: center;
  font-size: 50px;
}

.toSpace {
  text-align: right;
  text-decoration: none;
}

/*===*/
/* 搜索框布局 */
.search-form {
  /* flex布局 */
  margin-top: 250px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  position: relative;
  width: 800px;
  height: 100%;
  background: transparent;
  padding: 10px 5% 80px 5%;
  border-radius: 6px;
}

/* 整个大搜索框 */
.form-line {
  display: flex;
  /* 横向排布 */
  flex-direction: row;
  justify-content: space-between;
  /* 相对定位 */
  position: relative;
  background-color: #ffffff;
  height: 150%;
  width: 1200px;
  border: 1px solid #eee;
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 6%);
  padding: 10px;
  margin-bottom: 10px;
}

/* 出发-目的 */
.flt-box {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  position: relative;
  border-radius: 6px;
  border: 1px solid #eee;
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 6%);
}

/* 悬浮 */
.flt-box:hover {
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 10%);
}

/* 出发目的框的出发框 */
.flt-depart {
  display: flex;
  flex-direction: column;
  border-right: 1px solid, #eee;
}

/* 蓝底小字 */
.flt-depart span {
  color: #3187f9;
  font-size: 20px;
  margin: 10px 0px 4px 15px;
}

.flt-arrival {
  display: flex;
  flex-direction: column;
  left: 30px;
}

.flt-arrival span {
  color: #3187f9;
  font-size: 20px;
  margin: 10px 0px 4px 13px;
}

/* 交换按钮 */
.switch-button {
  position: relative;
  border: 1px solid;
  border-radius: 50%;
  width: 30px;
  height: 30px;
  top: 15px;
  left: -40px;
  cursor: pointer;
  background-color: #fff;
}

.select-box {
  margin: 10px 10px 10px 10px;
  width: 300px;
}

.date-box {
  display: flex;
  flex-direction: column;
  border: 1px solid;
  border-radius: 6px;
  width: 240px;
  border: 1px solid #eee;
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 6%);
}
.date-box:hover {
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 10%);
}

.date-box span {
  color: #3187f9;
  font-size: 20px;
  margin: 10px 0px 4px 13px;
}

.date-picker {
  margin: 10px 10px 10px 10px;
  width: 300px;
}

.search {
  position: absolute;
  top: 100%;
  left: 50%;
  transform: translateX(-50%) translateY(-50%);
  text-decoration: none;
}

.search-button {
  border-radius: 28px;
  height: 50px;
  width: 500px;
  padding-left: 30px;
  font-size: 25px;
  background-color: rgb(0, 0, 0);
  background-image: linear-gradient(-90deg, rgb(175, 252, 255), #b0daf6);
}

.search svg {
  position: absolute;
  left: 10%;
  top: 45%;
  transform: translateY(-50%);
  height: 30px;
  width: 30px;
  color: #fff;
}
</style>