<template>
  <div>
    <h1>Weather forecast</h1>
    <p>This component demonstrates fetching data from the server.</p>
    <div v-if="loading">Loading...</div>
    <div>
      <table>
        <thead>
        <tr>
          <th>Date</th>
          <th>Temp. (C)</th>
          <th>Temp. (F)</th>
          <th>Summary</th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="forecast in post" :key="forecast.date">
          <td>{{ forecast.date }}</td>
          <td>{{ forecast.temperatureC }}</td>
          <td>{{ forecast.temperatureF }}</td>
          <td>{{ forecast.summary }}</td>
        </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from 'vue';

const URL = 'https://localhost:7085';
console.log(URL);

type Forecasts = {
  date: string,
  temperatureC: string,
  temperatureF: string,
  summary: string
}[];

interface Data {
  loading: boolean,
  post: null | Forecasts
}

export default defineComponent({
  data(): Data {
    return {
      loading: false,
      post: null as Forecasts | null
    };
  },
  created() {
    // fetch the data when the view is created and the data is
    // already being observed
    this.fetchData();
  },
  watch: {
    // call again the method if the route changes
    '$route': 'fetchData'
  },
  methods: {
    fetchData(): void {
      this.post = null;
      this.loading = true;

      fetch(`${URL}/weatherforecast`)
          .then(r => r.json())
          .then(json => {
            this.post = json as Forecasts;
            this.loading = false;
            return;
          });
    }
  },
});
</script>
