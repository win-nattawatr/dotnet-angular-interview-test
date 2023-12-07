export const environment = {
  isProd: (import.meta.env['PROD'] as boolean) ?? true,
  apiBaseUrl: import.meta.env.NG_APP_BACKEND_API_URL ?? 'http://localhost:5001',
};
