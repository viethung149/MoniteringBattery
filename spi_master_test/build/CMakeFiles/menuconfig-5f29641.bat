cd /D C:\Users\ADMIN\Desktop\MoniteringBattery\spi_master_test\build || exit /b
C:\Users\ADMIN\.espressif\python_env\idf4.0_py3.8_env\Scripts\python.exe C:/Users/ADMIN/Desktop/esp-idf-2/tools/kconfig_new/confgen.py --kconfig C:/Users/ADMIN/Desktop/esp-idf-2/Kconfig --sdkconfig-rename C:/Users/ADMIN/Desktop/esp-idf-2/sdkconfig.rename --config C:/Users/ADMIN/Desktop/MoniteringBattery/spi_master_test/sdkconfig --env-file C:/Users/ADMIN/Desktop/MoniteringBattery/spi_master_test/build/config.env --env IDF_TARGET=esp32 --dont-write-deprecated --output config C:/Users/ADMIN/Desktop/MoniteringBattery/spi_master_test/sdkconfig || exit /b
C:\Users\ADMIN\.espressif\tools\cmake\3.13.4\bin\cmake.exe -E env "COMPONENT_KCONFIGS=C:/Users/ADMIN/Desktop/esp-idf-2/components/app_trace/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/bt/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/driver/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/efuse/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp-tls/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp32/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_adc_cal/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_common/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_eth/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_event/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_gdbstub/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_http_client/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_http_server/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_https_ota/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_https_server/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/esp_wifi/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/espcoredump/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/fatfs/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/freemodbus/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/freertos/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/heap/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/libsodium/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/log/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/lwip/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/mbedtls/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/mdns/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/mqtt/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/newlib/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/nvs_flash/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/openssl/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/pthread/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/spi_flash/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/spiffs/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/tcpip_adapter/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/unity/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/vfs/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/wear_levelling/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/wifi_provisioning/Kconfig C:/Users/ADMIN/Desktop/esp-idf-2/components/wpa_supplicant/Kconfig" "COMPONENT_KCONFIGS_PROJBUILD=C:/Users/ADMIN/Desktop/esp-idf-2/components/app_update/Kconfig.projbuild C:/Users/ADMIN/Desktop/esp-idf-2/components/bootloader/Kconfig.projbuild C:/Users/ADMIN/Desktop/esp-idf-2/components/esptool_py/Kconfig.projbuild C:/Users/ADMIN/Desktop/esp-idf-2/components/partition_table/Kconfig.projbuild" IDF_CMAKE=y KCONFIG_CONFIG=C:/Users/ADMIN/Desktop/MoniteringBattery/spi_master_test/sdkconfig IDF_TARGET=esp32 C:/Users/ADMIN/.espressif/tools/mconf/v4.6.0.0-idf-20190628/mconf-idf.exe C:/Users/ADMIN/Desktop/esp-idf-2/Kconfig || exit /b
C:\Users\ADMIN\.espressif\python_env\idf4.0_py3.8_env\Scripts\python.exe C:/Users/ADMIN/Desktop/esp-idf-2/tools/kconfig_new/confgen.py --kconfig C:/Users/ADMIN/Desktop/esp-idf-2/Kconfig --sdkconfig-rename C:/Users/ADMIN/Desktop/esp-idf-2/sdkconfig.rename --config C:/Users/ADMIN/Desktop/MoniteringBattery/spi_master_test/sdkconfig --env-file C:/Users/ADMIN/Desktop/MoniteringBattery/spi_master_test/build/config.env --env IDF_TARGET=esp32 --output config C:/Users/ADMIN/Desktop/MoniteringBattery/spi_master_test/sdkconfig || exit /b