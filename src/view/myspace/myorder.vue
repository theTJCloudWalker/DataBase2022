<template>
  <div>待出行:</div>
  <div>
    <el-table :data="orderTable" style="width: 100%">
      <el-table-column prop="date" label="出发日期" width="180" />
      <el-table-column prop="dep" label="出发机场" width="180" />
      <el-table-column prop="des" label="到达机场" width="180" />
      <el-table-column prop="time" label="起飞时间" width="180" />
    </el-table>
  </div>
</template>

<script>
export default {
  name: "myorder",
  components: {},
  data() {
    return {
      orderTable: [
        {
          date: "2202-2-20",
          dep: "T1",
          des: "T2",
          time: "19:50",
        },
      ],
    };
  },
};
</script>

<style scoped>
</style>
