// Copyright 2025 Robert Adams
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Extensions.Hosting;

using org.herbal3d.mblue.Logging;

namespace org.herbal3d.mblue.comm {

    public class CommService : BackgroundService {
        private readonly ICommProvider m_comm;
        private readonly MBLogger<CommService> m_log;

        public CommService(MBLogger<CommService> pLog,
                              ICommProvider pComm
                              ) {
            m_log = pLog;
            m_comm = pComm;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            m_log.Log(MBLogLevel.DCOMM, "Starting CommService");
            await m_comm.StartAsync(stoppingToken);
            m_log.Log(MBLogLevel.DCOMM, "Commervice started");
        }

        public override async Task StopAsync(CancellationToken cancellationToken) {
            m_log.Log(MBLogLevel.DCOMM, "Stopping CommService");
            await m_comm.StopAsync(cancellationToken);
            m_log.Log(MBLogLevel.DCOMM, "CommService stopped");
        }
    }
}
