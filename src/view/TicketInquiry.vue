<template>
  <div>
    <!-- **====================** -->
    <div class="topBar">
      <router-link to="/" class="topButton">
        <el-button>首页</el-button>
      </router-link>
    </div>
    <!-- **====================** -->
    <div class="form-container">
      <el-form label-width="120px" ref="TicketInquiry" :model="form">
        <!-- ========地点输入======== -->

        <div class="form-line">
          <div class="flt-box">
            <!-- =======起始地选择======= -->
            <div class="flt-depart">
              <span>出发地</span>
              <div class="select-box">
                <el-select
                  v-model="form.dep"
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
                  v-model="form.des"
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
          <!-- 日期选择 -->
          <div class="date-box">
            <span>出发日期</span>
            <div class="date-picker">
              <el-date-picker
                v-model="form.depDate"
                type="date"
                placeholder="选择出发日期"
              />
            </div>
          </div>
          <!-- 日期选择结束 -->

          <!-- 航程类别选择 舱位选择 -->
          <div class="cls-box-flight">
            <el-form-item>
              <el-radio-group v-model="form.pass">
                <span>请选择航程类别</span>
                <el-radio :label="1" size="large">单程</el-radio>
                <el-radio :label="2" size="large">往返</el-radio>
                <el-radio :label="3" size="large">多程</el-radio>
              </el-radio-group>
            </el-form-item>
          </div>
          <!--  -->
          <div class="cls-box-cabin">
            <el-form-item>
              <div>
                <el-radio-group v-model="form.cabin">
                  <span>请选择机舱类别</span>
                  <el-radio :label="1" size="large">经济舱</el-radio>
                  <el-radio :label="2" size="large">公务舱</el-radio>
                  <el-radio :label="3" size="large">头等舱</el-radio>
                </el-radio-group>
              </div>
            </el-form-item>
          </div>
          <!--  -->
          <div>
            <router-link to="" class="search">
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
            </router-link>
          </div>
          <!--  -->
        </div>
      </el-form>
    </div>
    <!-- 地点输入结束 -->

    <!-- 展示搜索结果 -->
    <div class="resultDIV">
      <div class="searchResult">
        <br /><br />
        <p>搜索结果:</p>
        <el-table
          :data="flightTable"
          height="250"
          width="1200"
          ref="singleTableRef"
          highlight-current-row
          @current-change="handleCurrentChange"
        >
          <el-table-column prop="date" label="日期" width="200" />
          <el-table-column prop="company" label="航空公司" width="200" />
          <el-table-column prop="flight" label="航班" width="150" />
          <el-table-column prop="departureSearch" label="起始地" width="100" />
          <el-table-column
            prop="departureAirplane"
            label="起飞机场"
            width="100"
          />
          <el-table-column
            prop="destinationSearch"
            label="目的地"
            width="100"
          />
          <el-table-column
            prop="destinationAirplane"
            label="降落机场"
            width="100"
          />
          <el-table-column prop="depTime" label="起飞时间" width="100" />
          <el-table-column prop="price" label="价格" width="100" />
          <el-table-column>
            <template #default="scope">
              <el-button
                size="small"
                type="primary"
                @click="handlePay(scope.$index, scope.row)"
                >订购</el-button
              >
            </template>
          </el-table-column>
        </el-table>
      </div>
    </div>
  </div>
  <!-- 搜索结果展示完毕 -->
</template>


<script>
import { ref } from "vue";
import { ElTable } from "element-plus";
export default {
  name: "TicketInquiry",
  components: {},
  props: ["departure", "destination"], //没卵用，没法传参

  data() {
    return {
      cacheDep: "", //缓存上一个填入的地点，用来处理同地点
      cacheDes: "",
      /*======表单数据======*/
      form: {
        dep: this.departure, //出发
        des: this.destination, //目的地
        // dep:this.departure,
        // des:this.destination,
        pass: 1, //行程类别
        cabin: 1, //舱类
        depDate: "",
      },
      /*============*/
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
      /*====应该从后端获得的数据=====*/
      flightTable: [
        {
          flight: "MU6060",
          company: "东方航空",
          date: "2016-05-03",
          departureSearch: "上海市",
          destinationSearch: "北京市",
          departureAirplane: "虹桥T1",
          destinationAirplane: "天安门",
          depTime: "10:30",
          price: "700",
        },
        {
          flight: "MU7060",
          company: "东方航空",
          date: "2016-05-03",
          departureSearch: "上海市",
          destinationSearch: "北京市",
          departureAirplane: "虹桥T1",
          destinationAirplane: "天安门",
          depTime: "10:30",
          price: "700",
        },
        {
          flight: "MU7060",
          company: "春秋航空",
          date: "2016-05-03",
          departureSearch: "上海市",
          destinationSearch: "北京市",
          departureAirplane: "虹桥T1",
          destinationAirplane: "天安门",
          depTime: "10:30",
          price: "700",
        },
        {
          flight: "MU7060",
          date: "2016-05-03",
          departureSearch: "上海市",
          destinationSearch: "北京市",
          departureAirplane: "虹桥T1",
          destinationAirplane: "天安门",
          depTime: "10:30",
          price: "700",
        },
        {
          flight: "MU7060",
          date: "2016-05-03",
          departureSearch: "上海市",
          destinationSearch: "北京市",
          departureAirplane: "虹桥T1",
          destinationAirplane: "天安门",
          depTime: "10:30",
          price: "700",
        },
      ],
    };
  },

  methods: {
    /*===========工具函数============*/
    exchange() {
      //交换函数
      let temp = "";
      temp = this.form.dep;
      this.form.dep = this.form.des;
      this.form.des = temp;
      console.log(this.form.pass);
    },
    setCacheDep() {
      //设置缓冲下同
      this.cacheDep = this.form.dep;
    },
    setCacheDes() {
      this.cacheDes = this.form.des;
    },
    /*====================================*/

    /*======该方法是：通过点击按钮，向后端发送数据，然后返回得到的数据===*/
    ticketInquiry() {
      // ctx.$axios.post("url", );
      // console.log(this.departure);
    },

    handlePay(x, y) {
      //跳转到支付订购
    },
  },

  watch: {
    'form.dep'() {
      //监视器，监视相同时交换
      if (this.form.dep === this.form.des) {
        this.form.dep = this.cacheDep;
        this.exchange();
      }
    },
    'form.des'() {
      //监视器，监视相同时交换
      if (this.form.dep === this.form.des) {
        this.form.des = this.cacheDes;
        this.exchange();
      }
    },
  },

  mounted() {
    this.form.depDate = new Date();
  },

  /*=====数据、方法======*/
  // setup() {
  //   let pass = ref(0); //行程类别
  //   let cabin = ref(0); //舱类
  //   const value1 = ref(""); //date

  //   return {
  //     dep: this.departure, //出发日期
  //     des: "", //目的地日期
  //     // dep:this.departure,
  //     // des:this.destination,
  //     pass, //行程类别
  //     cabin, //舱类
  //     ifshow: 1,
  //     value1: "0",
  //     date: ["2000", "2021"],
  //     flightTable: [
  //       {
  //         date: "2016-05-03",
  //         departureSearch: "上海市",
  //         destinationSearch: "北京市",
  //         flight: "MU6060",
  //       },
  //     ],
  //   };
  // },
  /*====================*/
};
</script>


<style scoped>
/* 顶部栏 */
.topBar {
  display: inline-block;
  margin-bottom: 30px;
  border-style: solid;
  border-bottom-color: black;
  border-width: 0, 0, 0, 0;
  text-decoration: none;
}

/*  顶部按钮  */
.topButton {
  text-decoration: none;
}

.form-container {
  width: 100%;
  height: 100%;
  background-size: cover;
  position: relative;
  display: flex;
  flex-direction: column;
  position: relative;
  align-items: center;
  background-color: rgb(255, 255, 255);
}

/* 输入框 */
.input {
  width: 350px;
}

/* 选项 */
.option {
  margin-left: 55px;
  margin-top: 20px;
}

/* 选择 */
.select {
  margin-left: 55px;
  margin-top: 20px;
}

.topinfo {
  text-align: center;
  height: 50px;
}

/* 搜索结果 */
.searchResult {
  margin-left: 55px;
  margin-right: 55px;
  margin-top: -50px;
  border: rgb(238, 169, 169);
  border-width: 1px;
  background-color: rgb(250, 250, 250);
  padding-bottom: 85px;
}

.searchResult p {
  font-size: 20px;
  top: -20px;
}

.resultDIV {
  background-color: rgb(250, 250, 250);
}

.Buy {
  text-align: right;
  margin-top: 20px;
  margin-right: 150px;
}

/*==========*/

/*===*/
/* 搜索框布局 */
.search-form {
  /* flex布局 */
  margin-top: 0px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  position: relative;
  width: 800px;
  height: 100%;
  background: transparent;
  padding: 10px 5% 0px 5%;
  border-radius: 6px;
}

/* 整个大搜索框 */
.form-line {
  display: flex;
  flex-wrap: wrap;
  /* 横向排布 */
  flex-direction: row;
  justify-content: space-between;
  /* 相对定位 */
  position: relative;
  background-color: #ffffff;
  height: 100%;
  width: 1200px;
  border: 1px solid #eee;
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 6%);
  padding: 10px;
  top: 0px;
}

/* 出发-目的-日期-选类别的框 */
.flt-box {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  position: relative;
  border-radius: 6px;
  border: 1px solid #eee;
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 6%);
}

.date-box {
  display: flex;
  flex-direction: column;
  border: 1px solid;
  border-radius: 6px;
  width: 400px;
  border: 1px solid #eee;
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 6%);
}

.cls-box-flight {
  display: flex;
  margin-top: 50px;
  flex-direction: column;
  width: 500px;
  right: -50px;
}

.cls-box-cabin {
  display: flex;
  margin-top: 50px;
  flex-direction: column;
  width: 500px;
}
/* 蓝底小字 */
.flt-depart span {
  color: #3187f9;
  font-size: 20px;
  margin: 10px 0px 4px 15px;
}

.flt-arrival span {
  color: #3187f9;
  font-size: 20px;
  margin: 10px 0px 4px 15px;
}

.date-box span {
  color: #3187f9;
  font-size: 20px;
  margin: 10px 0px 4px 15px;
}

.cls-box-flight span {
  color: #3187f9;
  font-size: 20px;
  margin: 0px 30px 4px -50px;
}

.cls-box-cabin span {
  color: #3187f9;
  font-size: 20px;
  margin: 0px 30px 4px -200px;
}
/* ====== */
/* 悬浮 */
.flt-box:hover {
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 10%);
}

.date-box:hover {
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 10%);
}

/* .cls-box-flight:hover {
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 10%);
}

.cls-box-cabin:hover {
  box-shadow: 0 0 12px 0 rgb(0 0 0 / 10%);
} */

/* 出发目的框的出发框 */
.flt-depart {
  display: flex;
  flex-direction: column;
  border-right: 1px solid, #eee;
}

.flt-arrival {
  display: flex;
  flex-direction: column;
  left: 30px;
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

.date-picker {
  margin: 10px 10px 10px 10px;
  width: 300px;
}

.search {
  position: relative;
  top: 50%;
  left: 70%;
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

/*===*/
</style>