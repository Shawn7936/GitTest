#ifndef _UPGRADE_LIB_H_
#define _UPGRADE_LIB_H_

int open_debug_log();

int WinUpgradeLibInit(char *Image_buffer_pointer, unsigned long ImageLen);
int burnImage();
int burnpartition(int parts_selected);

int progress_reply_status_get (char *index, unsigned char *percent, unsigned short *status );

int upload_file(char *buf, unsigned int* len_of_transfer, char *abs_filename_in_target);
int download_file(char *buf, unsigned int len_of_transfer, char *abs_filename_in_target);
int exec_file_in_tg(char* filepath);
#endif // _MFG_PROCESS_H_