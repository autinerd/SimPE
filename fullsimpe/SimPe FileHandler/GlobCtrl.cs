/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
#define QUAXI
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
    public partial class GlobCtrl : UserControl
    {
        public GlobCtrl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Stores the currently active Wrapper
        /// </summary>
        internal IFileWrapperSaveExtension wrapper = null;	

        #region GLOB
        private void GlobCommit(object sender, System.EventArgs e)
        {
            try
            {
                Glob wrp = (Glob)wrapper;

                wrp.SemiGlobalName = this.cbseminame.Text;
                wrapper.SynchronizeUserData();
                MessageBox.Show(Localization.Manager.GetString("commited"));
            }
            catch (Exception ex)
            {
                Helper.ExceptionMessage(Localization.Manager.GetString("errwritingfile"), ex);
            }
        }

        private void SemiGlobalChanged(object sender, System.EventArgs e)
        {
            if (cbseminame.SelectedIndex < 0)
            {
                for (int i = 0; i < cbseminame.Items.Count; i++)
                {
                    Data.SemiGlobalAlias a = cbseminame.Items[i] as Data.SemiGlobalAlias;
                    if (a.Name.ToLower() == cbseminame.Text.ToLower())
                    {
                        cbseminame.SelectedIndex = i;
                        return;
                    }
                }
                tbgroup.Text = "0x" + Helper.HexString(Hashes.GroupHash(cbseminame.Text));
            }
            else
            {
                Data.SemiGlobalAlias a = cbseminame.Items[cbseminame.SelectedIndex] as Data.SemiGlobalAlias;
                tbgroup.Text = "0x" + Helper.HexString(a.Id);
            }

            if (cbseminame.Tag == null)
            {
                try
                {
                    Glob wrp = (Glob)wrapper;
                    wrp.SemiGlobalName = this.cbseminame.Text;
                    wrapper.Changed = true;
                }
                catch (Exception ex)
                {
                    Helper.ExceptionMessage("", ex);
                }
            }
        }
        #endregion

    }
}
