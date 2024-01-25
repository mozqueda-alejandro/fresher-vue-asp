// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },
  ssr: false,
  spaLoadingTemplate: true,
  modules: [
    'nuxt-primevue'
  ],
  primevue: {
    options: {
      unstyled: true,
      ripple: true,
      inputStyle: 'filled'
    }
  },
  css: ['primevue/resources/themes/aura-dark-noir/theme.css']
})
