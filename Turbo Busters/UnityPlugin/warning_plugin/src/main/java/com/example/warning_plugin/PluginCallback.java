package com.example.warning_plugin;

import java.util.Stack;

public interface PluginCallback {
    public void onPositive(String message);
    public void onNegative(String message);
}
