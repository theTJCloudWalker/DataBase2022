<template>
    <div style="margin-top: 20px">
    <el-button @click="toggleSelection(tableData)"
      >Allselect</el-button
    >
    <el-button @click="toggleSelection()">Clear selection</el-button>
  </div>
   <el-table
    ref="multipleTableRef"
    :data="tableData"
    style="width: 100% ; margin-top: 50px"
    @selection-change="handleSelectionChange"
  >
    <el-table-column type="selection" width="55" />
    <el-table-column label="Date" width="120">
      <template #default="scope">{{ scope.row.date }}</template>
    </el-table-column>
    <el-table-column property="name" label="Name" width="120" />
    <el-table-column property="content" label="Content" show-overflow-tooltip />
  </el-table>
  
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import { ElTable } from 'element-plus'
import { forEach } from 'lodash';

interface UserMessage {
  date: string
  name: string
  content: string
}

const multipleTableRef = ref<InstanceType<typeof ElTable>>()
const multipleSelection = ref<UserMessage[]>([])
const toggleSelection = (rows?: UserMessage[]) => {
  if (rows) {
    rows.forEach((row) => {
      // TODO: improvement typing when refactor table
      // eslint-disable-next-line @typescript-eslint/ban-ts-comment
      // @ts-expect-error
      multipleTableRef.value!.toggleRowSelection(row, undefined)
    })
  } else {
    multipleTableRef.value!.clearSelection()
  }
}
const handleSelectionChange = (val: UserMessage[]) => {
  multipleSelection.value = val
}
const tableData = [
  {
    date: '2016-05-03',
    name: 'Tom',
    content: '你好',
  },
  {
    date: '2016-05-02',
    name: 'Tom',
    content: '你好',
  },
  {
    date: '2016-05-04',
    name: 'Tom',
    content: '你好',
  },
  {
    date: '2016-05-01',
    name: 'Tom',
    content: '你好',
  },
]
</script>