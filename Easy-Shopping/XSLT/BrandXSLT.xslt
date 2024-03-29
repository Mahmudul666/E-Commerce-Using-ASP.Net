﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <div class="main">
      <h2>View Brands</h2>
      <xsl:for-each select="Brands/BrandsId">
        <div class="box">
          <h3>
            <xsl:value-of select="Name"/>
          </h3>
          <br/>         
        </div>
      </xsl:for-each>
    </div>
  </xsl:template>
</xsl:stylesheet>
