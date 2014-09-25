﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" omit-xml-declaration="yes" indent="yes"/>
  
  <xsl:template match="@* | node()">
    <html>
      <body>
        <table>
          <tr>
            <xsl:for-each select="/*/node()">
              <xsl:if test="position()=1">
                <xsl:for-each select="*">
                  <td>
                    <xsl:value-of select="local-name()"/>
                  </td>
                </xsl:for-each>
              </xsl:if>
            </xsl:for-each>
          </tr>
          <xsl:for-each select="*">
            <tr>
              <xsl:for-each select="*">
                <td>
                  <xsl:value-of select="."/>
                </td>
              </xsl:for-each>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
