#!/bin/sh

# exit if a command fails
set -e

# verbose / debug print commands
set -v

FABRIC=Fabric
SECRETS=${FABRIC}/fabric.properties
CRASHLYTICS_DEVTOOL=${FABRIC}/crashlytics-devtools.jar

# download crashlytics tools if needed
if [ ! -f ${CRASHLYTICS_DEVTOOL} ]; then
  curl -L https://fabric.io/download/ant -o crashlytics.zip
  unzip -n crashlytics.zip -x *.xml -d ${FABRIC}
  rm crashlytics.zip
fi

# generate
java -jar ${CRASHLYTICS_DEVTOOL} -verbose \
  -properties "${SECRETS}" \
  -projectPath "${FABRIC}" \
  -androidManifest "Properties/AndroidManifest.xml" \
  -androidRes "Resources" \
  -androidAssets "Assets" \
  -generateResourceFile
